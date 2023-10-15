import { Component, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent implements OnInit {
  isLogged : boolean | undefined
  role: string | null;

  constructor(private router: Router, public service: UserService) {
  }
  
  ngOnInit() {
    this.service.defineRole();
  }

  onLogout() {
    localStorage.removeItem('token');
    this.service.role = undefined
    this.router.navigate(['/user/login']);
  }
}