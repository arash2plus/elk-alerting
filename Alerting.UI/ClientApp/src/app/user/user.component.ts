import { Inject } from '@angular/core';
import { Component } from '@angular/core';    
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';   
import { AlertingService } from '../services/alerting.service';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
})
 

export class UserComponent {

  user={
    email:''
  }
  users:User[];
  _applicationId:number; 
  constructor(private alertingService:AlertingService ,@Inject(MAT_DIALOG_DATA) public applicationId ){ 
    this._applicationId=applicationId.applicationId
  }

  ngOnInit(): void { 
    this.retrieveApplication();
  }
 
  retrieveApplication(): void {  
    this.alertingService.getAllUser(this._applicationId) 
      .subscribe(
        data => { 
          console.log(data);
          this.users=data
        },
        error => {
          console.log(error);

        });
  }

  saveUser():void{  
    if(this.user.email=="")
    {
      return;
    }
    const data = {
      email: this.user.email,
      applicationId:this._applicationId
    };
    
    this.alertingService.createUser(data)
      .subscribe(
        response => { 
          this.retrieveApplication(); 
          alert('عملیات با موفقیت انجام شد'); 
          this.user.email=null;
        },
        error => { 
          alert(error.error)
        }); 
  }

  deleteUser(id):void{ 
    if(confirm("Are you sure to delete ")) {
      this.alertingService.deleteUser(id)
      .subscribe(
        response => { 
          this.retrieveApplication(); 
          alert('عملیات با موفقیت انجام شد'); 
          this.user.email=null;
        },
        error => {
          alert(error.error)
        }); 
    }
    }


}
 



interface User{
  email:string,
  enable:boolean
} 

 

