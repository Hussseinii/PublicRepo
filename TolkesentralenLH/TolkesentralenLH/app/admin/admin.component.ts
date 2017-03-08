import { Component } from '@angular/core';
import { DataService } from '../_services/data.service'
import { NavbarElement } from '../_models/models'

@Component({
  selector: 'admin',
  templateUrl: "./app/admin/admin.component.html"
})

export class AdminComponent  {
    sum: string;
    antallOppdrag: number;
    antallOversettelser: number;

    element: NavbarElement;
    temp: any;

    constructor(private dataService: DataService) {}

    ngOnInit() {
      this.dataService.getData().subscribe(data => {
        this.temp = data;
        this.element = this.temp;
        
        switch(this.element.element){
          case 'oppdrag': this.antallOppdrag = this.element.nr;break;
          case 'oversettelse': this.antallOversettelser = this.element.nr;break;
        }
        this.sum = this.getSum();
      })
    }

    getSum(){
      var sum: number = 0;
      sum += this.antallOppdrag  == null ? 0 : this.antallOppdrag ; 
      sum += this.antallOversettelser  == null ? 0 : this.antallOversettelser;
      return sum == 0 ? "" : "" + sum;
    }

 }