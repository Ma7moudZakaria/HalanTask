import { Routes } from '@angular/router';
import { TicketListComponent } from './ticket-list/ticket-list.component';
import { CreateTicketComponent } from './create-ticket/create-ticket.component';

export const routes: Routes = [
    { path: '', redirectTo: 'tickets', pathMatch: 'full' },
    { path: 'tickets', component: TicketListComponent },
    { path: 'create-ticket', component: CreateTicketComponent },
    // Add other routes as needed
  ];
