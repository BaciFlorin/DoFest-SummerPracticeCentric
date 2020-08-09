import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthorizationInterceptor } from './interceptors/authorization.interceptor'
import { JwtModule } from "@auth0/angular-jwt";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './guards/auth.guard';
import { ActivityModule } from './activity/activity.module';
import { AdminGuard } from './guards/admin.guard';
import { BucketlistModule } from './bucketlist/bucketlist.module';
import { MatLabel, MatFormField } from '@angular/material/form-field';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    HttpClientModule,
    ReactiveFormsModule,
    ActivityModule,
    JwtModule.forRoot({
      config:{
        tokenGetter: () => sessionStorage.getItem('userToken'),
        allowedDomains: [],
        disallowedRoutes:[]
      }
    })
  ],
  providers: [
    AuthGuard,
    AdminGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizationInterceptor,
      multi:true
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
