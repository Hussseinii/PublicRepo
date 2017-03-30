import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { AppComponent }  from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { AuthenticationService } from './_services/auth.service';
import { AuthGuard } from './_guards/auth.guard';
import { OppdragService } from './_services/oppdrag.service'
import { TempService } from './_services/temp.service'
import { DataService } from './_services/data.service'

import { HttpModule } from '@angular/http';
// used to create fake backend
import { fakeBackendProvider } from './_helpers/fake-backend';
import { MockBackend, MockConnection } from '@angular/http/testing';
import { BaseRequestOptions } from '@angular/http';

import { LoginComponent } from './login/login.comonent';
import { HomeModule }      from './home/home.module';
import { PageNotFoundComponent }   from './shared/not-found.component';

@NgModule({
  imports:      [ BrowserModule, HomeModule, ReactiveFormsModule, AppRoutingModule, HttpModule],
  declarations: [ AppComponent, LoginComponent, PageNotFoundComponent],
  providers: [
        AuthGuard,
        AuthenticationService,
        OppdragService,
        TempService,
        DataService,

        // providers used to create fake backend
        fakeBackendProvider,
        MockBackend,
        BaseRequestOptions
    ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
