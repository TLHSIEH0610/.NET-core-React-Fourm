import { createBrowserRouter, RouteObject, Navigate } from "react-router-dom";
import ActivityDashboard from "../../features/activities/list/Activities";
import ActivityDetails from "../../features/activities/details/ActivityDetails";
import ActivityForm from "../../features/activities/form/ActivityForm";
import App from "../layout/App";
import NotFound from "../../features/errors/NotFound";
import ServerError from "../../features/errors/ServerError";
import ProfilePage from "../../features/profiles/ProfilePage";
import AuthGuard from "./AuthGuard";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
      {
        element: <AuthGuard />,
        children: [
          { path: "activities", element: <ActivityDashboard /> },
          { path: "activities/:id", element: <ActivityDetails /> },
          { path: "activities/create", element: <ActivityForm key="create" /> }, //add key to force re-render
          { path: "activities/edit/:id", element: <ActivityForm key="edit" /> },
          { path: "profiles/:id", element: <ProfilePage /> },
        ],
      },
      { path: "not-found", element: <NotFound /> },
      { path: "server-error", element: <ServerError /> },
      { path: "*", element: <Navigate replace to="/not-found" /> },
    ],
  },
];

export const router = createBrowserRouter(routes);
