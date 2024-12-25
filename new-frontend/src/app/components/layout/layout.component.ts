import { Component, OnInit, ViewChild, ElementRef, HostListener } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { trigger, transition, style, animate, state } from '@angular/animations';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
  animations: [
    trigger('slideContent', [
      transition(':enter', [
        style({ transform: 'translateX(-100%)' }),
        animate('200ms ease-out', style({ transform: 'translateX(0)' }))
      ]),
      transition(':leave', [
        animate('200ms ease-in', style({ transform: 'translateX(-100%)' }))
      ])
    ])
  ]
})
export class LayoutComponent implements OnInit {
  @ViewChild('mainContent') mainContent!: ElementRef;
  
  isCollapsed = false;
  isMobile = false;
  isSidebarOpen = true;
  
  menuItems = [
    { 
      icon: 'dashboard', 
      text: 'Dashboard', 
      route: '/dashboard',
      active: true
    },
    { 
      icon: 'person_outline', 
      text: 'Meu Perfil', 
      route: '/my-user' 
    },
    { 
      icon: 'group', 
      text: 'Usuários', 
      route: '/users' 
    },
    { 
      icon: 'assessment', 
      text: 'Relatórios', 
      route: '/reports' 
    },
    { 
      icon: 'settings', 
      text: 'Configurações', 
      route: '/settings' 
    }
  ];

  constructor(
    private router: Router,
    private authService: AuthService
  ) {
    this.checkScreenSize();
  }

  @HostListener('window:resize')
  onResize() {
    this.checkScreenSize();
  }

  checkScreenSize() {
    this.isMobile = window.innerWidth < 768;
    if (this.isMobile) {
      this.isCollapsed = false;
      this.isSidebarOpen = false;
    } else {
      this.isSidebarOpen = true;
    }
  }

  ngOnInit() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        if (this.isMobile) {
          this.isSidebarOpen = false;
        }
      }
    });
  }

  toggleSidebar() {
    if (this.isMobile) {
      this.isSidebarOpen = !this.isSidebarOpen;
    } else {
      this.isCollapsed = !this.isCollapsed;
    }
  }

  closeSidebar() {
    if (this.isMobile) {
      this.isSidebarOpen = false;
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}

