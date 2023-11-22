import {Component, OnDestroy, OnInit} from '@angular/core';
import {Chart} from "../../models/chart";
import {BarChartService} from "../../services/bar-chart.service";
import {ChartType} from "angular-google-charts";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent implements OnInit, OnDestroy {
  chartType = ChartType.BarChart;
  chartData: any[] = [];
  chartColumns: string[] = [];
  currentSelection: 'users' | 'projects' = 'users';
  selectedOption: string = 'users';
  private chartDataSubscription: Subscription = new Subscription();

  constructor(private barChartService: BarChartService) {
  }

  ngOnInit() {
    this.loadTopCandidateValues();
  }

  ngOnDestroy() {
    if (this.barChartService) {
      this.chartDataSubscription.unsubscribe();
    }
  }

  onOptionChange(value: string) {
    this.selectedOption = value;
    this.loadTopCandidateValues();
  }

  loadTopCandidateValues() {
    this.barChartService.getChart(this.selectedOption);
    this.chartColumns = this.currentSelection === 'users' ?
      ['User Name', 'Hours Worked']
      : ['Project Name', 'Hours Worked'];
    this.chartDataSubscription = this.barChartService.chartData$.subscribe(
      data => {
        this.chartData = data;
      }
    );
  }
}
