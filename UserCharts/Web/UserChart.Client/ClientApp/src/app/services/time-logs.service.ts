// src/app/services/time-logs.service.ts

import {Observable} from 'rxjs';
import {TimeLog} from "../models/time-log";
import {ApiService} from "./api.service";
import {Injectable} from "@angular/core";
import {HttpParams} from "@angular/common/http";

@Injectable({
  providedIn: 'root',
})
export class TimeLogsService{

  private timeLogPath: string ='timelogs/';


  constructor(private api: ApiService) { }

  ngOnInit() {
    this.getTimeLogs();
  }

  getTimeLogs(): Observable<TimeLog[]> {
    const path =`${this.timeLogPath}gettimelog`;
    return this.api.get(path);
  }

}
