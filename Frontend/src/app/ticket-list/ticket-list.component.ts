import { Component, OnInit } from '@angular/core';
import { TicketService } from '../../ticket-service';
import { Console } from 'console';
import { CommonModule, NgClass, NgFor, NgIf } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';

interface GetAllTicketRequest {
  pageNumber: number;
  pageSize: number;
}

interface GetAllTicketResponse{
  result: Ticket[];
  totalCount: number;
}

interface Ticket {
  id: string;
  creationDate: string;
  phoneNumber: string;
  governorate: string;
  city: string;
  district: string;
  isHandled: boolean;
}

@Component({
  selector: 'app-ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrl: './ticket-list.component.css',
  imports: [NgClass, NgIf, NgFor, NgxPaginationModule ],
  standalone: true
})

export class TicketListComponent implements OnInit {
  src: any;
  tickets: any;
  page: number = 1;  // Initialize the page property
  ticketRequest = { pageNumber: 1, pageSize: 5 } as GetAllTicketRequest;

  constructor(private ticketService: TicketService) {}

  ngOnInit() {
    console.log('Hello Hello Hello initialized');

    this.loadTickets(this.ticketRequest);
  }

  loadTickets(model: GetAllTicketRequest) {
    this.src = this.ticketService.getAllTickets(model).subscribe((data) => {

      console.log('tickets Results', data.result);

      this.tickets = data.result;
    });
  }

  handleTicket(id: string) {
    this.ticketService.updateTicket({id: id, isHandled: true}).subscribe(() => {
      this.loadTickets(this.ticketRequest);
    });
  }

  getColorClass(creationDate: any) {
    console.log('creationDate -------------->', new Date())

    const created = new Date(creationDate);

    console.log('created -------------->', created)

    const diffMinutes = this.calculateDifferenceInMinutes(created);

    console.log('diffMinutes -------------->', diffMinutes)

    if (diffMinutes < 15) return 'yellow';
    if (diffMinutes < 30) return 'green';
    if (diffMinutes < 60) return 'blue';
    return 'red';
  }

  calculateDifferenceInMinutes(createdDate: any): number {
    const now = new Date(); // Current date and time
    const diffMilliseconds = now.getTime() - createdDate.getTime(); // Difference in milliseconds
    const diffMinutes = diffMilliseconds / (1000 * 60); // Convert milliseconds to minutes
    return Math.floor(diffMinutes); // Round down to the nearest whole minute
  }

  ngOnDestroy() {
    this.src.unsubscribe();
  }
}

