import { Component } from '@angular/core';
import {LocationStrategy, PathLocationStrategy} from "@angular/common";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [
    Location, {
      provide: LocationStrategy,
      useClass: PathLocationStrategy
    }
  ],
})
export class AppComponent {
  title = 'app';
}
