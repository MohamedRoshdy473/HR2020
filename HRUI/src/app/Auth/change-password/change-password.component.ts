import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  Newpassword:string;
  constructor(private AuthService:AuthService,private router: Router) { }

  ngOnInit(): void {
  }
  onSubmit(event)
  {
    this.AuthService.changPassword(this.Newpassword).subscribe(
      data=>this.router.navigate(['/']),
      error=>console.log(error)
    )
  }

}
