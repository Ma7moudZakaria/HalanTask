import { Component } from '@angular/core';
import { TicketService } from '../../ticket-service';
import { NgClass, NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

interface CreateTicket {
  creationDate: string;
  phoneNumber: string;
  governorate: string;
  city: string;
  district: string;
  isHandled: boolean;
}

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrl: './create-ticket.component.css',  
  imports: [NgClass, NgIf, NgFor, FormsModule],
  standalone: true
})
export class CreateTicketComponent {
  ticket = {} as CreateTicket;

  // ticket = { phoneNumber: '', governorate: '', city: '', district: '' };

  governorates = ['Governorate1', 'Governorate2'];
  cities = ['City1', 'City2'];
  districts = ['District1', 'District2'];

  constructor(private ticketService: TicketService) {}

  createTicket() {
    this.ticketService.createTicket(this.ticket).subscribe(() => {
      // Handle success
    });
  }
}