import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import {Excuse} from 'src/app/Data_Types/excuse';
import {MenuItem} from 'primeng/api';
import { Timestamp } from 'rxjs/internal/operators/timestamp';
import {ExcuseService} from 'src/app/Services/excuse.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-excuse',
  templateUrl: './add-excuse.component.html',
  styleUrls: ['./add-excuse.component.css']
})
export class AddExcuseComponent implements OnInit {

  Excuse:Excuse
  constructor(private ExcuseService:ExcuseService,private router:Router) {
     this.Excuse={Approved:"pending",Date:new Date(Date.now()),Comment:'',Hours:0,Time:{hours:0,minutes:0}};
}

  ngOnInit(): void {
  }
  add()
  {
    console.log((this.Excuse));
    this.ExcuseService.addExcuse(this.Excuse).subscribe(
      res=>{       var usrRole =  localStorage.getItem("roles");
      if(usrRole == "Admin")
      {
      this.router.navigate(['/AllExcuses']); 
      }
      if(usrRole == "User")
      {
       // this.messageService.add({ severity: 'info', summary: 'Record Added!', detail: 'Record Added!' });
        this.router.navigate(['/AllExcuses']); 
      }
    },
      error=>console.log(error),
    );   
  }

}
