import { AuthService } from 'src/app/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as $ from 'jquery';
import { IUsuario } from 'src/app/interfaces/Usuario';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public hide = true;
  public message = '';
  public messageBemVindo = '';
  public sucesso = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    $(document).ready(function () {
      var animating = false,
        submitPhase1 = 1100,
        submitPhase2 = 400,
        logoutPhase1 = 800,
        $login = $('.login'),
        $app = $('.app');

      function ripple(elem: any, e: any) {
        $('.ripple').remove();
        var elTop = elem.offset().top,
          elLeft = elem.offset().left,
          x = e.pageX - elLeft,
          y = e.pageY - elTop;
        var $ripple = $("<div class='ripple'></div>");
        $ripple.css({ top: y, left: x });
        elem.append($ripple);
      }

      $(document).on('click', '.login__submit', function (e) {
        if (animating) return;
        animating = true;
        var that = this;
        ripple($(that), e);
        $(that).addClass('processing');
        setTimeout(function () {
          $(that).addClass('success');
          setTimeout(function () {
            $app.show();
            $app.css('top');
            $app.addClass('active');
          }, submitPhase2 - 70);
          setTimeout(function () {
            $login.hide();
            $login.addClass('inactive');
            animating = false;
            $(that).removeClass('success processing');
          }, submitPhase2);
        }, submitPhase1);
      });

      $(document).on('click', '.app__logout', function (e) {
        if (animating) return;
        $('.ripple').remove();
        animating = true;
        var that = this;
        $(that).addClass('clicked');
        setTimeout(function () {
          $app.removeClass('active');
          $login.show();
          $login.css('top');
          $login.removeClass('inactive');
        }, logoutPhase1 - 120);
        setTimeout(function () {
          $app.hide();
          animating = false;
          $(that).removeClass('clicked');
        }, logoutPhase1);
      });
    });
  }

  public logar() {
    const usuario: IUsuario = {
      Email: $('#Email').val()?.toString(),
      Senha: $('#Senha').val()?.toString(),
    };
    this.router.navigate(['index']);
    this.authService.logar(usuario).subscribe((response: any) => {
      var btn = document.getElementById('btncancel');
      this.sucesso = response.success;
      if (response.success) {
        this.message = 'Login realizado com sucesso!';
        this.messageBemVindo = 'Bem vindo ' + response.data.nome;
        setTimeout(() => {
          btn?.click();
          setTimeout(() => {
            this.router.navigate(['index']);
          }, 700);
        }, 3700);
      } else {
        this.message = 'Erro ao realizar o Login!';
       /* setTimeout(() => {
          btn?.click();
        }, 3700);*/
      }
    });
  }
}
