import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { ReportListComponent } from './components/report-list/report-list.component';
import { MyUserComponent } from './components/my-user/my-user.component';
import { SystemSettingsComponent } from './components/system-settings/system-settings.component';
import { LayoutComponent } from './components/layout/layout.component';
import { UserDialogComponent } from './components/user-dialog/user-dialog.component';
import { ReportDialogComponent } from './components/report-dialog/report-dialog.component';
import { SettingsDialogComponent } from './components/settings-dialog/settings-dialog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    UserListComponent,
    ReportListComponent,
    MyUserComponent,
    SystemSettingsComponent,
    LayoutComponent,
    UserDialogComponent,
    ReportDialogComponent,
    SettingsDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
