package com.emids.da.controllers;

/*
 * Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 * See full license at the bottom of this file.
 *
 * MIT License:
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * ""Software""), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

import com.emids.da.BaseController;
import com.emids.da.outlook.dto.Calendar;
import com.emids.da.outlook.dto.GraphArray;
import com.emids.da.outlook.dto.OrgUser;
import com.emids.da.outlook.dto.User;
import com.emids.da.outlook.msgraph.GraphCalendarService;
import com.emids.da.outlook.msgraph.GraphServiceHelper;
import com.emids.da.outlook.msgraph.GraphUserService;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class CalendarController extends BaseController {
  private static final long serialVersionUID = -2822076484402412061L;

  /**
     * @param request
     * @param response
     * @throws javax.servlet.ServletException
     * @throws java.io.IOException
     * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
   */
  // List a user's calendars
  @Override
  protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    User user = ensureUser(request);

    if (null == user) {
      // Not signed in
      response.sendRedirect("index.jsp");
      return;
    }

    // Selected user is set to the logged in user if the app is using single-user flow
    // If the app is using the organization flow, the user can change the selected user on the page
    String selectedUser = request.getParameter("selected-user");
    if (null != selectedUser) {
      request.setAttribute("selectedUser", selectedUser);
    } else {
      selectedUser = user.getId();
      request.setAttribute("selectedUser", selectedUser);
    }

    if (user.isConsentedForOrg()) {
      // If the is the org flow, we need to populate a drop down with a list of users
      // This executes every time the page loads, which isn't terribly efficient
      // It is probably a better idea to cache the user list in a database somewhere
      // Get list of users from Graph
      GraphUserService userService = GraphServiceHelper.getUserService();
      GraphArray<OrgUser> users = userService.getUsers("v1.0", user.getAccessToken()).execute().body();
      assert users != null;
      request.setAttribute("users", users.getValue());
    }

    GraphCalendarService calService = GraphServiceHelper.getCalendarService();
    GraphArray<Calendar> userCalendars;
    // Get list of user's calendars
    userCalendars = calService.getCalendars("v1.0", selectedUser, user.getAccessToken()).execute().body();
    request.setAttribute("calendars", null == userCalendars ? null : userCalendars.getValue());
    request.getRequestDispatcher("Calendars.jsp").forward(request, response);
  }

  /**
     * @param request
     * @param response
     * @throws javax.servlet.ServletException
     * @throws java.io.IOException
     * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
   */
  // Make some change to the user's calendar list (create, update, delete)
  @Override
  protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    User user = ensureUser(request);
    if (null == user) {
      // Not signed in
      response.sendRedirect("index.jsp");
      return;
    }

    String selectedUser = request.getParameter("selected-user");

    GraphCalendarService calService = GraphServiceHelper.getCalendarService();

    // Figure out which operation we are doing
    String calendarOp = request.getParameter("calendar-op");
    switch (calendarOp) {
      case "create":
        String name = request.getParameter("new-cal-name");
        String color = request.getParameter("new-cal-color");

        Calendar newCalendar = new Calendar(name, color);
        Calendar result = calService.createCalendar("v1.0", selectedUser, newCalendar, user.getAccessToken()).execute().body();
        break;
      case "rename":
        String updateId = request.getParameter("calendar-id");
        String newName = request.getParameter("new-name");
        Calendar update = new Calendar();
        update.setName(newName);
        calService.updateCalendar("v1.0", selectedUser, updateId, update, user.getAccessToken()).execute();
        break;
      case "delete":
        String deleteId = request.getParameter("calendar-id");
        calService.deleteCalendar("v1.0", selectedUser, deleteId, user.getAccessToken()).execute();
        break;
    }

    // Now that the change is made, reload the list of calendars
    doGet(request, response);
  }
}
