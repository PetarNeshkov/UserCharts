import {Component, OnInit, ViewChild} from '@angular/core';
import {TimeLog} from "../../models/time-log";
import {TimeLogsService} from "../../services/time-logs.service";
import {MatSort} from "@angular/material/sort";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {InitializeDatabaseService} from "../../services/initialize-database.service";
import {BarChartService} from "../../services/bar-chart.service";
import {Chart} from "../../models/chart";

@Component({
  selector: 'app-time-log',
  templateUrl: './time-log.component.html',
  styleUrls: ['./time-log.component.css']
})
export class TimeLogComponent implements OnInit {
  @ViewChild(MatSort, {static: true}) sort!: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator!: MatPaginator;

  displayedColumns: string[] = ['username', 'email', 'projectName', 'date', 'hoursWorked', 'id'];
  timeLog = new MatTableDataSource<TimeLog>([]);
  page: number = 1;
  from: Date | undefined = undefined;
  to: Date | undefined = undefined;

  constructor(
    private timeLogsService: TimeLogsService,
    private initializeDatabaseService: InitializeDatabaseService,
    private barChartService: BarChartService)
  {}

  ngOnInit() {
    this.timeLogsService.getTimeLogs(1).subscribe(res => {
      this.timeLog = new MatTableDataSource(res);
      this.timeLog.sort = this.sort;
      this.timeLog.paginator = this.paginator;
    });

    this.timeLogsService.getTimeLogsCount().subscribe(res => {
      this.paginator.length = res;
    });
  }

  onPageChange(event: any) {
    this.page = event.pageIndex + 1;
    this.loadTimeLogs();
  }

  applyDateFilter() {
    this.page = 1;
    this.paginator.pageIndex = 0;

    this.loadTimeLogs();

    const selectedOption = this.barChartService.selectedOption;

    this.barChartService.getChart(selectedOption,this.from,this.to);
  }

  initializeDatabase(){
    this.initializeDatabaseService.initializeDatabase().subscribe( {
      next: () => {
        window.location.reload();
      }
    });

    window.location.reload();
  }

  loadTimeLogs() {
    this.timeLogsService.getTimeLogs(this.page, this.from, this.to)
      .subscribe(res => {
        this.timeLog.data = res;
      });
  }
}
