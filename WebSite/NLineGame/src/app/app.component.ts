import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  columns = [1, 2, 3, 4, 5];
  rows = [1, 2, 3, 4, 5];

  ngOnInit(): void {
  }
}
