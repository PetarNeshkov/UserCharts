import { Injectable } from '@angular/core';
import {ApiService} from "./api.service";

@Injectable({
  providedIn: 'root'
})
export class InitializeDatabaseService {
  private initializeDatabasePath: string = 'initializedatabases/';

  constructor(private api: ApiService) {
  }

  initializeDatabase(){
    const path: string = `${this.initializeDatabasePath}resetdatabase`;

    return this.api.get(path);
  }
}
