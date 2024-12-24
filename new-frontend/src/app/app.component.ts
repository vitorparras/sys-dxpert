import { Component } from '@angular/core';
import { fadeAnimation } from './animations';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
  animations: [fadeAnimation]
})
export class AppComponent {
  title = 'Angular Dashboard';
}

