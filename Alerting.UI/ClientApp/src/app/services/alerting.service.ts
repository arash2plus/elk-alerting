import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'http://elk-alerting.nsedna.com/';

@Injectable({
    providedIn: 'root'
  })

  export class AlertingService{
      constructor(private http:HttpClient){}

      getAll():Observable<any>{
          return this.http.get(baseUrl+'api/Application/getApplications'); 
      }

      create(data): Observable<any> { 
        return this.http.post(baseUrl+'api/Application/addApplication', data);
      }


      getAllUser(applicationId):Observable<any>{  
        return this.http.get(baseUrl+'api/User/getUsersByApplicationId?applicationId=' +applicationId); 
    }
 
    deleteApplication(id): Observable<any> { 
      return this.http.delete(baseUrl+'api/Application/deleteApplication?id='+ id);
    }
    createUser(data): Observable<any> { 
      return this.http.post(baseUrl+'api/user/addUser', data);
    }

    deleteUser(id): Observable<any> { 
      return this.http.delete(baseUrl+'api/user/deleteUser?id='+ id);
    }
  }
