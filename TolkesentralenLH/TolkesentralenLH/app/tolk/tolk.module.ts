    import { NgModule }       from '@angular/core';
    import { CommonModule }   from '@angular/common';

    import { TolkComponent }     from './tolk.component';
    
    import { TolkRoutingModule } from './tolk-routing.module';
    

    @NgModule({
      imports: [
        CommonModule,
        TolkRoutingModule
      ],
      declarations: [
        TolkComponent
      ],
      //bootstrap: [ AppComponent ]
    })
    export class AdminModule { }