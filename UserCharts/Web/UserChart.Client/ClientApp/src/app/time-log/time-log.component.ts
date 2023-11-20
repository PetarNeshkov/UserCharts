import {Component, OnInit, ViewChild} from '@angular/core';
import {TimeLog} from "../models/time-log";
import {TimeLogsService} from "../services/time-logs.service";
import {MatSort} from "@angular/material/sort";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-time-log',
  templateUrl: './time-log.component.html',
  styleUrls: ['./time-log.component.css']
})
export class TimeLogComponent implements OnInit{
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  displayedColumns: string[] = ['username', 'email', 'projectName', 'date', 'hoursWorked'];
  timeLog = new MatTableDataSource<TimeLog>([]);

  constructor(private timeLogsService: TimeLogsService)
  {}

  ngOnInit() {
    this.timeLogsService.getTimeLogs().subscribe(res =>{
      this.timeLog = new MatTableDataSource(res);
      this.timeLog.sort = this.sort;
      this.timeLog.paginator = this.paginator;
    });
  }

}
