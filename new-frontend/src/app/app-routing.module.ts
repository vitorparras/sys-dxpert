import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/pages/dashboard/dashboard/dashboard.component';

import { LoginComponent } from './components/pages/login/login/login.component';
import { MyUserComponent } from './components/pages/my-user/my-user/my-user.component';
import { ReportListComponent } from './components/pages/reports/report-list/report-list.component';
import { SystemSettingsComponent } from './components/pages/settings/system-settings/system-settings.component';
import { UserListComponent } from './components/pages/user-list/user-list/user-list.component';
import { AdminGuard } from './guards/admin.guard';
import { AuthGuard } from './guards/auth.guard';
import { LayoutComponent } from './components/shared/layout/layout.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'users', component: UserListComponent },
      { path: 'reports', component: ReportListComponent },
      { path: 'my-user', component: MyUserComponent },
      { path: 'settings', component: SystemSettingsComponent, canActivate: [AdminGuard] },
      { path: '', redirectTo: '/dashboard', pathMatch: 'full' }
    ]
  },
  { 
    path: 'relatorio',
    loadChildren: () => import('./components/dxpert/cadastro-inicial/relatorio.module').then(m => m.RelatorioModule),
   // canActivate: [AuthGuard],
    },
  { path: '**', redirectTo: '/dashboard' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
