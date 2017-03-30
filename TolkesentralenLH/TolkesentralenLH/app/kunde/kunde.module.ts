    import { NgModule }       from '@angular/core';
    import { CommonModule }   from '@angular/common';

    import { KundeComponent }     from './kunde.component';
    
    import { KundeRoutingModule } from './kunde-routing.module';
    

    @NgModule({
      imports: [
        CommonModule,
        KundeRoutingModule
      ],
      declarations: [
        KundeComponent
      ],
      //bootstrap: [ AppComponent ]
    })
    export class AdminModule { }