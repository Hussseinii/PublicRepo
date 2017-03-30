import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { LoginModel } from '../_models/login';
import { AuthenticationService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'app/login/login.component.html',
})

export class LoginComponent  {
  
 skjema: FormGroup;
 error: string;

  constructor(
      private authService: AuthenticationService,
      private router: Router,
      private fb: FormBuilder ) {
        this.skjema = fb.group({
            // Skjekk om brukernavnet er en gyldig e-post adresse
            brukernavn: ["", Validators.pattern("[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,6}")],
            // Todo -> Begrensinger til passord
            passord: ["", Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")]
        });
  }

  onLogin() {
    var login = new LoginModel();
    login.brukernavn = this.skjema.value.brukernavn;
    login.passord = this.skjema.value.passord;
    var body: string = JSON.stringify(login);
    console.log(login);
    console.log(body);

    this.authService.login(this.skjema.value.brukernavn, this.skjema.value.passord)
            .subscribe(result => {
                if (result === true) {
                    this.router.navigate(['/admin']);

                    // Todo: fjern denne når ferdigtestet:
                    console.log("Godkjent innloggin");
                } else {
                    this.error = 'Username or password is incorrect';
                    
                }
            });
   
  }

  }