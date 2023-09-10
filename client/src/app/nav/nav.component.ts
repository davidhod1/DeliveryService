import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  model: any = {}
  
  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService){}

  ngOnInit(): void {
  
  }


  login(){
    this.accountService.login(this.model).subscribe({
      next: _ => this.router.navigateByUrl('/members')
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/login');
  }
}