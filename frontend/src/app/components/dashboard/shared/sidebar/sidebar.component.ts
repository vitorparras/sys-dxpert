import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

export class SeuModulo { }

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
  acao: string;
}

export const ROUTES: RouteInfo[] = [
  {
    path: '/index',
    title: 'Dashboard',
    icon: 'fa-solid fa-house',
    class: '',
    acao: ''
  },
  {
    path: '/usuario',
    title: 'Meu Perfil',
    icon: 'fa-solid fa-user',
    class: '',
    acao: ''
  },
  {
    path: '/usuarios',
    title: 'Usuarios',
    icon: 'fa-solid fa-users',
    class: '',
    acao: ''
  },
  {
    path: '/relatorios',
    title: 'Simulações',
    icon: 'fa-solid fa-file-lines',
    class: '',
    acao: ''
  },

  {
    path: '/acompanhamentos',
    title: 'Acompanhamentos',
    icon: 'fa-solid fa-list-check',
    class: '',
    acao: ''
  },
  {
    path: '/configuracoes',
    title: 'Configurações',
    icon: 'fa-solid fa-gears',
    class: '',
    acao: ''
  },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit {
  menuItems: any[] | undefined;
  index = '/index';

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter((menuItem) => menuItem);
  }

  isMobileMenu() {
    if (window.innerWidth > 991) {
      return false;
    }
    return true;
  }

  deslogar() {
    this.authService.deslogar();
  }
}
