import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppComponent } from './app.component';
import { TicketListComponent } from './ticket-list/ticket-list.component';
import { CreateTicketComponent } from './create-ticket/create-ticket.component';
import { routes } from './app.routes';
import { CommonModule } from '@angular/common';

console.log('Hello Hello Hello initialized');




@NgModule({
  declarations: [
    AppComponent,
    TicketListComponent,
    CreateTicketComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    NgxPaginationModule,
    FormsModule,
    RouterModule.forRoot(routes) // Ensure RouterModule is imported with routes
  ],
  providers: [provideHttpClient(withInterceptorsFromDi())], // add it here
  bootstrap: [AppComponent]
})
export class AppModule { }
