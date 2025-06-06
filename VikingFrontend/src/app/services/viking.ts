import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Viking } from '../models/viking.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VikingService {
  private apiUrl = environment.apiUrl + '/api/viking';

  constructor(private http: HttpClient) { }

  getVikings(): Observable<Viking[]> {
    return this.http.get<Viking[]>(this.apiUrl);
  }

  getViking(id: string): Observable<Viking> {
    return this.http.get<Viking>(`${this.apiUrl}/${id}`);
  }

  addViking(viking: Viking): Observable<Viking> {
    return this.http.post<Viking>(this.apiUrl, viking);
  }

  updateViking(id: string, viking: Viking): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, viking);
  }

  deleteViking(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
