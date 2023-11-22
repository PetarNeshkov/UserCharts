// src/app/services/time-logs.service.ts

import {Observable} from 'rxjs';
import {TimeLog} from "../models/time-log";
import {ApiService} from "./api.service";
import {Injectable} from "@angular/core";
import {BarChartService} from "./bar-chart.service";
import {Chart} from "../models/chart";
import {User} from "../models/user";

@Injectable({
  providedIn: 'root',
})
export class TimeLogsService {

  private timeLogPath: string = 'timelogs/';


  constructor(private api: ApiService, private barChartService: BarChartService) {
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

  getUserData(userId: string){
    let query = `?userId=${userId}`

    const path: string = `${this.timeLogPath}getuserdata${query}`;

    const result = this.api.get(path);

    result.subscribe(res => {
      const newDataEntry = [
        res.username,
        0,
        res.hoursWorked
      ];
      this.barChartService.chartDataSubject.next([newDataEntry]);
    })
  }

}
