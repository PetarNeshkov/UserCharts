// src/app/services/time-logs.service.ts

import {Observable} from 'rxjs';
import {TimeLog} from "../models/time-log";
import {ApiService} from "./api.service";
import {Injectable} from "@angular/core";
import {HttpParams} from "@angular/common/http";

@Injectable({
  providedIn: 'root',
})
export class TimeLogsService {

  private timeLogPath: string = 'timelogs/';


  constructor(private api: ApiService) {
  }

  getTimeLogs(page: number, dateFrom?: Date, dateTo?: Date): Observable<TimeLog[]> {
    let query = `?page=${page}`
    if (dateFrom) {
      query += `&from=${dateFrom.toLocaleDateString('en-CA')}`
    }
    if (dateTo) {
      query += `&to=${dateTo.toLocaleDateString('en-CA')}`
    }

    const path: string = `${this.timeLogPath}gettimelog${query}`;
    return this.api.get(path);
  }

  getTimeLogsCount(){
    const path: string = `${this.timeLogPath}gettimelogcount`;

    return this.api.get(path);
  }

}
