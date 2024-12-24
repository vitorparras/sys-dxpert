import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Chart, ChartConfiguration } from 'chart.js/auto';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  @ViewChild('salesChart') salesChart!: ElementRef;
  @ViewChild('distributionChart') distributionChart!: ElementRef;
  @ViewChild('topSellersChart') topSellersChart!: ElementRef;
  @ViewChild('conversionRateChart') conversionRateChart!: ElementRef;
  @ViewChild('customerGrowthChart') customerGrowthChart!: ElementRef;
  @ViewChild('claimsChart') claimsChart!: ElementRef;

  selectedPeriod = 'Último Mês';
  periods = ['Hoje', 'Última Semana', 'Último Mês', 'Último Ano'];

  metrics = [
    {
      title: 'Total de Vendas',
      value: 'R$ 1.250.000',
      change: '+15.3%',
      isPositive: true,
      icon: 'attach_money'
    },
    {
      title: 'Apólices Vendidas',
      value: '583',
      change: '+8.7%',
      isPositive: true,
      icon: 'description'
    },
    {
      title: 'Média por Apólice',
      value: 'R$ 2.144',
      change: '+5.2%',
      isPositive: true,
      icon: 'trending_up'
    },
    {
      title: 'Novos Clientes',
      value: '127',
      change: '+12.4%',
      isPositive: true,
      icon: 'person_add'
    },
    {
      title: 'Taxa de Renovação',
      value: '87%',
      change: '+2.1%',
      isPositive: true,
      icon: 'autorenew'
    },
    {
      title: 'Comissões Totais',
      value: 'R$ 187.500',
      change: '+14.8%',
      isPositive: true,
      icon: 'payments'
    }
  ];

  ngOnInit() {
    setTimeout(() => {
      this.initCharts();
    });
  }

  initCharts() {
    this.initSalesChart();
    this.initDistributionChart();
    this.initTopSellersChart();
    this.initConversionRateChart();
    this.initCustomerGrowthChart();
    this.initClaimsChart();
  }

  initSalesChart() {
    const ctx = this.salesChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'bar',
      data: {
        labels: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun'],
        datasets: [
          {
            label: 'Auto',
            data: [65000, 59000, 80000, 81000, 56000, 55000],
            backgroundColor: 'rgba(255, 99, 132, 0.5)',
          },
          {
            label: 'Vida',
            data: [28000, 48000, 40000, 19000, 86000, 27000],
            backgroundColor: 'rgba(54, 162, 235, 0.5)',
          },
          {
            label: 'Residencial',
            data: [35000, 39000, 42000, 31000, 36000, 45000],
            backgroundColor: 'rgba(255, 206, 86, 0.5)',
          }
        ]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            position: 'top',
          },
          title: {
            display: true,
            text: 'Vendas Mensais por Tipo de Seguro'
          }
        },
        scales: {
          y: {
            beginAtZero: true,
            border: {
              display: false
            },
            grid: {
              color: 'rgba(0, 0, 0, 0.1)'
            }
          },
          x: {
            grid: {
              display: false
            },
            border: {
              display: false
            }
          }
        }
      }
    });
  }

  initDistributionChart() {
    const ctx = this.distributionChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'doughnut',
      data: {
        labels: ['Auto', 'Vida', 'Residencial', 'Saúde', 'Viagem'],
        datasets: [{
          data: [30, 25, 20, 15, 10],
          backgroundColor: [
            'rgba(255, 99, 132, 0.7)',
            'rgba(54, 162, 235, 0.7)',
            'rgba(255, 206, 86, 0.7)',
            'rgba(75, 192, 192, 0.7)',
            'rgba(153, 102, 255, 0.7)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            position: 'right',
          },
          title: {
            display: true,
            text: 'Distribuição de Vendas por Tipo de Seguro'
          }
        }
      }
    });
  }

  initTopSellersChart() {
    const ctx = this.topSellersChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'bar',
      data: {
        labels: ['João', 'Maria', 'Pedro', 'Ana', 'Carlos'],
        datasets: [{
          label: 'Vendas (R$)',
          data: [120000, 98000, 85000, 72000, 65000],
          backgroundColor: 'rgba(75, 192, 192, 0.7)',
          borderColor: 'rgba(75, 192, 192, 1)',
          borderWidth: 1
        }]
      },
      options: {
        indexAxis: 'y',
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: false,
          },
          title: {
            display: true,
            text: 'Top 5 Vendedores'
          }
        },
        scales: {
          x: {
            beginAtZero: true,
            border: {
              display: false
            },
            grid: {
              color: 'rgba(0, 0, 0, 0.1)'
            }
          },
          y: {
            grid: {
              display: false
            },
            border: {
              display: false
            }
          }
        }
      }
    });
  }

  initConversionRateChart() {
    const ctx = this.conversionRateChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'line',
      data: {
        labels: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun'],
        datasets: [{
          label: 'Taxa de Conversão (%)',
          data: [12, 15, 18, 14, 20, 22],
          fill: false,
          borderColor: 'rgba(255, 159, 64, 1)',
          tension: 0.4
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: false,
          },
          title: {
            display: true,
            text: 'Taxa de Conversão de Leads'
          }
        },
        scales: {
          y: {
            beginAtZero: true,
            border: {
              display: false
            },
            grid: {
              color: 'rgba(0, 0, 0, 0.1)'
            }
          },
          x: {
            grid: {
              display: false
            },
            border: {
              display: false
            }
          }
        }
      }
    });
  }

  initCustomerGrowthChart() {
    const ctx = this.customerGrowthChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'line',
      data: {
        labels: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun'],
        datasets: [{
          label: 'Número de Clientes',
          data: [1000, 1150, 1280, 1420, 1580, 1720],
          fill: true,
          backgroundColor: 'rgba(153, 102, 255, 0.2)',
          borderColor: 'rgba(153, 102, 255, 1)',
          tension: 0.4
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: false,
          },
          title: {
            display: true,
            text: 'Crescimento de Clientes'
          }
        },
        scales: {
          y: {
            beginAtZero: true,
            border: {
              display: false
            },
            grid: {
              color: 'rgba(0, 0, 0, 0.1)'
            }
          },
          x: {
            grid: {
              display: false
            },
            border: {
              display: false
            }
          }
        }
      }
    });
  }

  initClaimsChart() {
    const ctx = this.claimsChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'line',
      data: {
        labels: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun'],
        datasets: [{
          label: 'Número de Reclamações',
          data: [50, 45, 60, 55, 40, 35],
          fill: false,
          borderColor: 'rgba(255, 99, 132, 1)',
          tension: 0.4
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: false,
          },
          title: {
            display: true,
            text: 'Tendência de Reclamações'
          }
        },
        scales: {
          y: {
            beginAtZero: true,
            border: {
              display: false
            },
            grid: {
              color: 'rgba(0, 0, 0, 0.1)'
            }
          },
          x: {
            grid: {
              display: false
            },
            border: {
              display: false
            }
          }
        }
      }
    });
  }
}

