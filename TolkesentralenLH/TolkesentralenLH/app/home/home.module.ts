    import { NgModule }       from '@angular/core';
    import { BrowserModule }  from '@angular/platform-browser';
    import { FormsModule }    from '@angular/forms';
    import { CommonModule }   from '@angular/common';

    import { HomeRoutingModule } from './home-routing.module';
    import { HomeComponent }     from './home.component';
    import { PageNotFoundComponent } from '../shared/not-found.component';

    @NgModule({
      imports: [
        CommonModule,
        BrowserModule,
        FormsModule,
        HomeRoutingModule
      ],
      declarations: [
        HomeComponent
      ],
      //bootstrap: [ AppComponent ]
    })
    export class HomeModule { }