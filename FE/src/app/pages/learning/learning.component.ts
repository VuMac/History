import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-learning',
  templateUrl: './learning.component.html',
  styleUrls: ['./learning.component.scss']
})
export class LearningComponent implements OnInit {

  options: any[];
  selectedOption: any;
  constructor() {
    this.options = [
      { name: "C#" },
      { name: "Java" },
      { name: "Reactjs" }
    ]
  }

  ngOnInit(): void {
  }

}
