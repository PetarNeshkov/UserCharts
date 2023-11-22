import {Injectable} from '@angular/core';
import {ApiService} from "./api.service";
import {Chart} from "../models/chart";
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class BarChartService {
  public selectedOption: string = '';
  private userChartsPath: string = 'charts/';
  private chartDataSubject = new BehaviorSubject<any[]>([]);
  public chartData$ = this.chartDataSubject.asObservable();

  constructor(private api: ApiService) {
  }

  getChart(selectedOption: string ,dateFrom?: Date, dateTo?: Date){
    let query =`?selectedoption=${selectedOption}`;

    if (dateFrom) {
      query += `&from=${dateFrom.toLocaleDateString('en-CA')}`
    }
    if (dateTo) {
      query += `&to=${dateTo.toLocaleDateString('en-CA')}`
    }

    this.selectedOption = selectedOption;

    const path: string = `${this.userChartsPath}chartresult${query}`;

    const result= this.api.get(path);

    result.subscribe(res => {
      const result= res.map((chart: Chart) => [chart.keyNameValue, chart.hoursWorked]);
      this.chartDataSubject.next(result);
    })
  }
}
