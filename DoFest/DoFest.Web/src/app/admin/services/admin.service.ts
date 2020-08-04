import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const backendEndpoint = "https://localhost:5001/api/v1/"
const endpoints = {
  "activities": backendEndpoint + "activities",
  "activityType": backendEndpoint + "activities/type",
  "cities": backendEndpoint + "cities"
};

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private httpClient: HttpClient = null;

  constructor(httpClient: HttpClient) {
    this.httpClient = httpClient;
  }
}
