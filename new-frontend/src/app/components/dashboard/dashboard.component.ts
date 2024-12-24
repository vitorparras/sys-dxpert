import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Chart, registerables } from 'chart.js';

Chart.register(...registerables);

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  @ViewChild('barChart') barChart!: ElementRef;
  @ViewChild('pieChart') pieChart!: ElementRef;
  @ViewChild('lineChart') lineChart!: ElementRef;

  selectedPeriod: string = 'month';

  ngOnInit() {
    this.createBarChart();
    this.createPieChart();
    this.createLineChart();
  }

  createBarChart() {
    const ctx = this.barChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'bar',
      data: {
        labels: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho'],
        datasets: [{
          label: 'Vendas',
          data: [12, 19, 3, 5, 2, 3],
          backgroundColor: 'rgba(63, 81, 181, 0.2)',
          borderColor: 'rgba(63, 81, 181, 1)',
          borderWidth: 1
        }]
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }

  createPieChart() {
    const ctx = this.pieChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'pie',
      data: {
        labels: ['Produtos', 'Serviços', 'Assinaturas'],
        datasets: [{
          data: [300, 150, 100],
          backgroundColor: [
            'rgba(63, 81, 181, 0.2)',
            'rgba(103, 58, 183, 0.2)',
            'rgba(33, 150, 243, 0.2)'
          ],
          borderColor: [
            'rgba(63, 81, 181, 1)',
            'rgba(103, 58, 183, 1)',
            'rgba(33, 150, 243, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'bottom'
          }
        }
      }
    });
  }

  createLineChart() {
    const ctx = this.lineChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'line',
      data: {
        labels: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho'],
        datasets: [{
          label: 'Usuários Ativos',
          data: [65, 59, 80, 81, 56, 55],
          fill: false,
          borderColor: 'rgb(63, 81, 181)',
          tension: 0.1
        }]
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }
}

