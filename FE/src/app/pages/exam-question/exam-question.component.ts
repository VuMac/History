import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-exam-question',
  templateUrl: './exam-question.component.html',
  styleUrls: ['./exam-question.component.css']
})
export class ExamQuestionComponent implements OnInit {

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
