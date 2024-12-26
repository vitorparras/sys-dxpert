import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatChipsModule} from '@angular/material/chips';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/pages/login/login/login.component';
import { DashboardComponent } from './components/pages/dashboard/dashboard/dashboard.component';
import { UserListComponent } from './components/pages/user-list/user-list/user-list.component';
import { ReportListComponent } from './components/pages/reports/report-list/report-list.component';
import { MyUserComponent } from './components/pages/my-user/my-user/my-user.component';
import { SystemSettingsComponent } from './components/pages/settings/system-settings/system-settings.component';
import { UserDialogComponent } from './components/pages/user-list/user-dialog/user-dialog.component';
import { ReportDialogComponent } from './components/pages/reports/report-dialog/report-dialog.component';
import { SettingsDialogComponent } from './components/pages/settings/settings-dialog/settings-dialog.component';

import { AuthGuard } from './guards/auth.guard';
import { AdminGuard } from './guards/admin.guard';
import { AppRoutingModule } from './app-routing.module';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ForgotPasswordModalComponent } from './components/pages/login/forgot-password-modal/forgot-password-modal.component';
import { ConfirmDialogComponent } from './components/shared/confirm-dialog/confirm-dialog.component';
import { UserMetricsModalComponent } from './components/pages/user-list/user-metrics-modal/user-metrics-modal.component';
import { ReportNotesComponent } from './components/pages/reports/report-notes/report-notes.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { LayoutComponent } from './components/shared/layout/layout.component';
import { ReportPresentationComponent } from './components/pages/reports/report-presentation/report-presentation.component';
import { PhoneMaskDirective } from './directives/phone-mask.directive';
import { InputMaskDirective } from './directives/input-mask.directive';
import { DateMaskDirective } from './directives/date-mask.directive';
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
    SettingsDialogComponent,
    ForgotPasswordModalComponent,
    ConfirmDialogComponent,
    UserMetricsModalComponent,
    ReportNotesComponent,
    ReportPresentationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatButtonModule,
    MatInputModule,
    MatCardModule,
    MatTableModule,
    MatDialogModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatSortModule,
    MatSnackBarModule,
    MatProgressSpinnerModule,
    MatMenuModule,
    MatDividerModule,
    MatTooltipModule,
    MatSlideToggleModule,
    MatFormFieldModule,
    MatButtonToggleModule,
    MatChipsModule,
  ],
  providers: [AuthGuard, AdminGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
