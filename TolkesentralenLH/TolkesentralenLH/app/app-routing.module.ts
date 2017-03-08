    import { NgModule }              from '@angular/core';
    import { RouterModule, Routes }  from '@angular/router';
    import { PageNotFoundComponent } from './shared/not-found.component';
    import { HomeModule } from './home/home.module';
    import { LoginComponent } from './login/login.comonent';
    import { AuthGuard } from './_guards/auth.guard';

    const appRoutes: Routes = [
      { path: 'login', component: LoginComponent},
      {
        path: 'admin',
        loadChildren: 'app/admin/admin.module#AdminModule',
        canActivate: [AuthGuard]
      },
      {
        path: 'kunde',
        loadChildren: 'app/kunde/kunde.module#AdminModule'
      },
      {
        path: 'tolk',
        loadChildren: 'app/tolk/tolk.module#AdminModule'
      },
      { path: '',   redirectTo: '/home', pathMatch: 'full' },
      { path: '**', component: PageNotFoundComponent }
    ];
    @NgModule({
      imports: [
        RouterModule.forRoot(appRoutes)
      ],
      exports: [
        RouterModule
      ]
    })
    export class AppRoutingModule {}