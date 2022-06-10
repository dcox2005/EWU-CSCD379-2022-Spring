<template>
  <div class>
    <v-container @click="toggleDialog">
    {{userName}}
      <v-icon>mdi-account-circle</v-icon>
    </v-container>
    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-container>
          <v-card-title>User Login</v-card-title>
            <v-form method="post" @submit.prevent="submitLogIn">
              <v-container>
                <v-row>
                  <v-col 
                    cols="12"
                  >
                    <v-text-field
                      v-model="userEmail"
                      label="User E-Mail"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      v-model="password"
                      label="Password"
                      required
                    >
                    </v-text-field>
                  </v-col>
                </v-row>
              </v-container>
              <v-row>
                <v-col cols="12" md="3">
                  <v-btn type="submit">Log In</v-btn>
                </v-col>
                <v-col cols="12" md="3">
                </v-col>
                <v-col cols="12" md="3">
                  <v-btn @click="clearToken()">Log Out</v-btn>
                </v-col>
              </v-row>
            </v-form>
        </v-container>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { JWT } from '~/scripts/jwt'

@Component({})
export default class UserLogin extends Vue {
  dialog = false
  userName: string = "Guest"
  userEmail: string = '';
  password: string = '';

  toggleDialog() {
    this.dialog = !this.dialog
  }

  mounted()
  {
    var token = localStorage.getItem('token');
    if (token == null  || token == undefined)
    {
      this.userName = "Guest";
      token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIiLCJqdGkiOiIiLCJVc2VySWQiOiIiLCJSYW5kb20iOiIwIiwiVXNlck5hbWUiOiJHdWVzdCIsIkJpcnRoRGF0ZSI6IiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJHdWVzIl0sImV4cCI6MCwiaXNzIjoiV29yZGxlLkFQSSIsImF1ZCI6IldvcmRsZS13ZWIifQ.ZJPfULKgo94NQB03lrc_ctoCn7rI5rYybWMPkOspyqsOJzSfqkUmjIqZRRnNOhcUkLkBc41y_XVk9IANj1jmXA";
      JWT.setToken(token,this.$axios)
    }
    else
    {
      JWT.setToken(token,this.$axios)
      this.userName = JWT.tokenData.UserName;
      this.userEmail = JWT.tokenData.sub;
    }
    localStorage.setItem('userName', this.userName)
  }

  retrieveToken()
  {
    this.$axios
        .post('Token/GetToken', {
          username: this.userEmail,
          password: this.password,
        })
        .then((result) => 
        {
          JWT.setToken(result.data.token,this.$axios);
          this.userName = JWT.tokenData.UserName;
          localStorage.setItem('token', result.data.token);
          localStorage.setItem('userName', this.userName);
setTimeout(() => {
console.log(`Token Data for verification: 
Random: ${JWT.tokenData.Random}
UserId: ${JWT.tokenData.UserId}
UserName: ${JWT.tokenData.UserName}
BirthDateString: ${JWT.tokenData.BirthDate}
Age: ${JWT.age}
aud: ${JWT.tokenData.aud}
exp: ${JWT.tokenData.exp}
iss: ${JWT.tokenData.iss}
jti: ${JWT.tokenData.jti}
sub: ${JWT.tokenData.sub}
Roles: ${JWT.tokenData.roles}
`)
}, 2000);
        });
    this.$forceUpdate();
  }

  submitLogIn()
  {
    this.retrieveToken();
    this.password = "";
  }

  clearToken()
  {
    this.userName = "Guest";
    JWT.reset();
    localStorage.setItem('userName', this.userName);
    localStorage.removeItem('token');
    this.$forceUpdate();
  }

}
</script>