import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  registerMode = false;
  loginMode = false;

  constructor(private router: Router, private accountService: AccountService){}

  ngOnInit(): void {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => {
        if (user) this.router.navigate(['dashboard']);
      }
    })
  }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  loginToggle(){
    this.loginMode = !this.loginMode;
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }
}
