import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseResponseModel } from './base-response-model';
// import { GetAllTicketRequest } from './GetAllTicketRequest';
// import { UpdateTicket } from './UpdateTicket';
// import { CreateTicket } from './CreateTicket';
// import { GetAllTicketResponse } from './GetAllTicketResponse';

interface CreateTicket {
    creationDate: string;
    phoneNumber: string;
    governorate: string;
    city: string;
    district: string;
    isHandled: boolean;
}

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
    creationDate: Date;
    phoneNumber: string;
    governorate: string;
    city: string;
    district: string;
    isHandled: boolean;
}

interface UpdateTicket {
    id: string;
    isHandled: boolean;
}

@Injectable({
  providedIn: 'root',
})

export class TicketService {
  private apiUrl = 'https://localhost:7253/api/ticket/';

  getAllTicketsURL = this.apiUrl + 'getAll/';
  createTicketURL = this.apiUrl + 'create';
  updateTicketURL = this.apiUrl + 'update';

  constructor(private http: HttpClient) {
    console.log('TicketService initialized');
  }

  getAllTickets(model: GetAllTicketRequest): Observable<GetAllTicketResponse> {
    return this.http.get<GetAllTicketResponse>(this.getAllTicketsURL+model.pageNumber+'/'+model.pageSize);
  }

  createTicket(model: CreateTicket): Observable<BaseResponseModel> {
    return this.http.post<BaseResponseModel>(this.createTicketURL, model);
  }

  updateTicket(model: UpdateTicket): Observable<BaseResponseModel> {
    console.log('UpdateTicket initialized', this.http.put<BaseResponseModel>(this.updateTicketURL, model));


    return this.http.put<BaseResponseModel>(this.updateTicketURL, model);
  }
}
