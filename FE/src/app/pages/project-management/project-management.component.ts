import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-project-management',
  templateUrl: './project-management.component.html',
  styleUrls: ['./project-management.component.scss']
})
export class ProjectManagementComponent implements OnInit {

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
