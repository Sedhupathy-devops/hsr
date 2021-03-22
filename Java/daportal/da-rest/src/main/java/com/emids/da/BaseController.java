package com.emids.da;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import com.emids.da.outlook.auth.AuthHelper;
import com.emids.da.outlook.dto.User;

public class BaseController extends HttpServlet {

  // Helper method to make sure there is a user in the session
  // and check if the access token is expired. Refresh the token
  // if it is expired.
  protected User ensureUser(HttpServletRequest request) {
    HttpSession session = request.getSession();
    User user = (User) session.getAttribute("user");

    if (null == user) {
      return null;
    }

    if (user.isTokenExpired()) {
      String authServlet = user.isConsentedForOrg() ? "AuthorizeOrganization" : "AuthorizeUser";
      StringBuffer requestUrl = request.getRequestURL();
      String redirectUrl = requestUrl.replace(requestUrl.lastIndexOf("/") + 1, requestUrl.length(), authServlet)
          .toString();

      user.setTokenObj(AuthHelper.getTokenSilently(user, redirectUrl, this.getServletContext()));
      session.setAttribute("user", user);
    }

    return user;
  }
}
