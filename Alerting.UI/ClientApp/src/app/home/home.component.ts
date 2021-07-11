import { Component } from '@angular/core';    
import { MatDialog } from '@angular/material'; 
import { CounterComponent } from '../counter/counter.component';
import { AlertingService } from '../services/alerting.service';
import { UserComponent } from '../user/user.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
 

export class HomeComponent {


  application={
    applicationName:''
  }
  applications:Applications[]; 
  constructor(private alertingService:AlertingService,public dialog: MatDialog ){
 
  }

  ngOnInit(): void {
    this.retrieveApplication();
  }


   saveApplication():void{ 
     if(this.application.applicationName=="")
     {
      alert('لطفا اپلیکیشن را وارد نمایید'); 
      return
     }
    const data = {
      applicationName: this.application.applicationName,
    };
    
    this.alertingService.create(data)
      .subscribe(
        response => {
          console.log(response); 
          this.retrieveApplication(); 
          alert('عملیات با موفقیت انجام شد'); 
        },
        error => {
          alert(error.error);
          this.application.applicationName=null;
        }); 
  }
  retrieveApplication(): void {
    this.alertingService.getAll()
      .subscribe(
        data => {
          this.applications = data;
          console.log(data);
        },
        error => {
          console.log(error);

        });
  }
  showUserDialog(applicationId:number):void{
    const dialogRef = this.dialog.open(UserComponent,{
      data:{
        applicationId
      }
    });
  }

  deleteApplication(id):void{
    if(confirm("Are you sure to delete ")) {
      this.alertingService.deleteApplication(id)
      .subscribe(
        response => { 
          this.retrieveApplication(); 
          alert('عملیات با موفقیت انجام شد'); 
          this.application.applicationName=null;
        },
        error => {
          alert(error.error)
        }); 
    }
  }
}
interface Applications{
  applicationName:string
} 

