import { Component, OnInit } from '@angular/core';
import { User } from '../entities/user';
import { UserService } from '../services/user.service';
import { ChangeDetectorRef } from '@angular/core';

declare let gapi: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public user: User;
  public visible: boolean;
  protected auth2: any;
cd: ChangeDetectorRef;

  constructor(private ref: ChangeDetectorRef, private userService: UserService) {
    this.visible = false;
    this.cd = ref;
   }

  ngOnInit(): void {
    this.visible = false;
    this.cd.detectChanges();

    gapi.load('auth2', () => {
      this.auth2 = gapi.auth2.init({
        client_id: '1013960723581-e2q1dv9kg4gpou4aul76fmgq5c68ktjv.apps.googleusercontent.com',
        cookiepolicy: 'single_host_origin',
        setPrompt: 'select_account',
        scope: 'profile email'
      });
      this.auth2.then(() => {
        if (this.auth2.isSignedIn.get()) {
          console.log('signed in', gapi.auth2.getAuthInstance().isSignedIn.get());
            this.login();
        } else {
          this.signIn();
        }
      }).catch((err: any) => {
        this.user = null;
        this.signOut();
      });
  });
  }

  signIn() {
    this.visible = true;
    this.cd.detectChanges();
    if (!this.auth2.isSignedIn.get()) {
      const promise = this.auth2.signIn();
      promise.then(() => {
        this.login();
        // resolve(this.user);
        }).catch((err: any) => {
           this.user = null;
           this.signOut();
        });
      }
}

signOut(): Promise<any> {
  return new Promise((resolve, reject) => {
    this.auth2.signOut().then((err: any) => {
      if (err) {
        reject(err);
      } else {
        resolve();
      }
    }).catch((err: any) => {
      reject(err);
    });
  });
}

login() {
  const profile = this.auth2.currentUser.get().getBasicProfile();
  this.user = new User();
  this.user.name = profile.getName();
  this.user.email = profile.getEmail();
  this.user.photoUrl = profile.getImageUrl();
  this.cd.detectChanges();
  this.userService.loginUser(this.user).subscribe(data => {
  });
}


}
