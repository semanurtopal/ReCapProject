import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, NavigationStart } from '@angular/router';
import { Location, PopStateEvent } from '@angular/common';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/models/user';
import { StorageService } from 'src/app/services/storage.service';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
    public isCollapsed = true;
    private lastPoppedUrl: string;
    private yScrollStack: number[] = [];

    user: User
    identityId: number
    rememberMe: boolean
    isLogin: boolean

    constructor(public location: Location, private router: Router, 
      private storageService: StorageService, private userService:UserService, private toastrService:ToastrService) {
    }

    ngOnInit() {
      this.router.events.subscribe((event) => {
        this.isCollapsed = true;
        if (event instanceof NavigationStart) {
           if (event.url != this.lastPoppedUrl)
               this.yScrollStack.push(window.scrollY);
       } else if (event instanceof NavigationEnd) {
           if (event.url == this.lastPoppedUrl) {
               this.lastPoppedUrl = undefined;
               window.scrollTo(0, this.yScrollStack.pop());
           } else
               window.scrollTo(0, 0);
       }
     });
     this.location.subscribe((ev:PopStateEvent) => {
         this.lastPoppedUrl = ev.url;
     });

      this.checkLogin()
    }

    isHome() {
        var titlee = this.location.prepareExternalUrl(this.location.path());

        if( titlee === '#/home' ) {
            return true;
        }
        else {
            return false;
        }
    }
    isDocumentation() {
        var titlee = this.location.prepareExternalUrl(this.location.path());
        if( titlee === '#/documentation' ) {
            return true;
        }
        else {
            return false;
        }
    }

    checkLogin(){
        if (this.storageService.getFromLocal("rememberMe") === "true") {
          this.isLogin = true
    
          this.identityId = parseInt(this.storageService.getFromLocal("identityId"))
          this.getUserById()
          
          this.rememberMe = true
        } else if (this.storageService.getFromSession("rememberMe") === "false"){
          this.isLogin = true
    
          this.identityId = parseInt(this.storageService.getFromSession("identityId"))
          this.getUserById()
    
          this.rememberMe = false
        } else {
          this.isLogin = false
        }  
      }
    
      getUserById(){
        this.userService.getUserById(this.identityId).subscribe(response =>{
          this.user = response.data
        })
      }
    
      signOut(){
        this.toastrService.success("Successfully logged out the system", "Success")
    
        if (this.rememberMe) {
          this.identityId = null
          this.storageService.deleteFromLocal("rememberMe")
          this.storageService.deleteFromLocal("token")
          this.storageService.deleteFromLocal("identityId")
    
          this.storageService.deleteFromLocal("rememberMyCard");

          for (let i = 1; i <= parseInt(this.storageService.getFromLocal("rememberableCardNumber")); i++) {
            this.storageService.deleteFromLocal("card"+i.toString())         
          }
    
          this.storageService.deleteFromLocal("rememberableCardNumber")         
        } else {
          this.identityId = null
          this.storageService.deleteFromSession("rememberMe")
          this.storageService.deleteFromSession("token")
          this.storageService.deleteFromSession("identityId")
          
          this.storageService.deleteFromLocal("rememberMyCard");

          for (let i = 1; i <= parseInt(this.storageService.getFromLocal("rememberableCardNumber")); i++) {
            this.storageService.deleteFromLocal("card"+i.toString())         
          }
    
          this.storageService.deleteFromLocal("rememberableCardNumber")       
        }
    
        setTimeout(() =>{
          window.location.replace("/login");
        }, 1150)
      }
}
