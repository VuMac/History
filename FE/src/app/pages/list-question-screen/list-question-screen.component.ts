import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-list-question-screen',
  templateUrl: './list-question-screen.component.html',
  styleUrls: ['./list-question-screen.component.scss']
})
export class ListQuestionScreenComponent implements OnInit {
  options: any[];
  dataproduct:any=[];
  selectedOption: any;
  modelDetail : any = {};
  // view
  displayDetail : boolean = false;
  displayCreateNew : boolean = false;
  constructor(private httpClient: HttpClient) {
    this.options = [
      { name: "C#" },
      { name: "Java" },
      { name: "Reactjs" }
    ]  
    this.httpClient.get<any>("assets/data.json").subscribe(data =>{
      this.dataproduct = data.data;
    })
  }

  ngOnInit(): void {
    
  }
  clicktoDetail(model){
    this.modelDetail = model;
    this.displayDetail = true;
  }

  clickToCreatNew(){
    this.displayCreateNew = true;
  }

}
