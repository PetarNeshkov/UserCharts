import {Component, OnDestroy, OnInit} from '@angular/core';
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
  chartOptions: any = {
    colors: ['blue', 'red'],
    legend: {position: 'top', maxLines: 3},
  };
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
      ['User Name', 'Hours Worked', 'Comparision']
      : ['Project Name', 'Hours Worked', 'Comparision'];
    this.chartDataSubscription = this.barChartService.chartData$.subscribe(
      data => {
        //check if there is single entity to add
        if (data.length === 1) {
          this.populateChart(data);
        }
        //populate chart
        else if (data.length > 0) {
          this.chartData = data;
        }
      }
    );
  }

  private populateChart(data: any) {
    const username = data[0][0];
    const hoursWorked = data[0][2];
    const existingEntryIndex = this.chartData.findIndex(entry => entry[0] === username);

    // Find if an entry with the same username already exists in chartData
    if (existingEntryIndex !== -1) {
      // If an entry exists, append the comparision hours worked
      this.chartData[existingEntryIndex][2] = hoursWorked;

      this.chartData = [...this.chartData];
    } else {
      // If no entry exists, push the new data item into chartData

      this.chartData = [...this.chartData, ...data];
    }
  }

}
