import React, { useState } from "react";
import {
  Box,
  Container,
  TextField,
  Typography,
  Divider,
  Stack,
  Button,
} from "@mui/material";
import { makeStyles } from "@mui/styles";
import FacebookIcon from "@mui/icons-material/Facebook";
import GoogleIcon from "@mui/icons-material/Google";
import TwitterIcon from "@mui/icons-material/Twitter";
import Headers from '@ecommerce/shared-components/components/Header';
import {apiClient} from '@ecommerce/shared-components/api/apiClient';
import {useAuthStore} from '@ecommerce/shared-components/stores/useAuthStore';

// Define styles using Material-UI's makeStyles
const useStyles = makeStyles({
  container: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    justifyContent: "center",
    minHeight: "60vh",
    backgroundColor: "#f8fafc",
    padding: "5rem",
    margin: "5rem auto",
    borderRadius: "10px",
  },
  card: {
    backgroundColor: "white",
    padding: "2rem",
    borderRadius: "8px",
    boxShadow: "0 4px 10px rgba(0, 0, 0, 0.1)",
    width: "100%",
    maxWidth: "400px",
  },
  logo: {
    fontFamily: "Roboto, sans-serif",
    fontWeight: 700,
    color: "#333",
    textAlign: "center",
    marginBottom: "1rem",
  },
  highlight: {
    color: "#007bff",
  },
  form: {
    marginTop: "1rem",
  },
  button: {
    marginTop: "1rem",
    backgroundColor: "#007bff",
    color: "white",
    padding: "0.75rem",
    borderRadius: "4px",
    textAlign: "center",
    fontWeight: "bold",
    cursor: "pointer",
    "&:hover": {
      backgroundColor: "#0056b3",
    },
  },
  divider: {
    margin: "2rem 0",
    fontSize: "0.9rem",
    color: "#666",
  },
  socialIcon: {
    fontSize: "2rem",
    cursor: "pointer",
    transition: "color 0.3s ease, transform 0.3s ease",
    "&:hover": {
      color: "#007bff",
      transform: "scale(1.2)",
    },
  },
});

const Login: React.FC = () => {
  const classes = useStyles();

  // State for form fields and validation
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [errors, setErrors] = useState<{ username?: string; password?: string }>(
    {}
  );

interface ResultObj {
  authResponse: AuthResponse;
}
interface AuthResponse {
  isAuthenticated: boolean;
  accessToken: string;
  refreshToken: string;
}

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();

  // Validate fields
  const newErrors: { username?: string; password?: string } = {};
  if (!username) {
    newErrors.username = "Username is required";
  }
  if (!password) {
    newErrors.password = "Password is required";
  }

  setErrors(newErrors);

  // If no errors, proceed with login logic
  if (Object.keys(newErrors).length === 0) {
    try {
      const result = await apiClient<ResultObj>("http://localhost:5056/api/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ email: username, password }),
      });

      if (result.authResponse.isAuthenticated) {
        // Store tokens and username in the auth store
        useAuthStore.getState().setUser(
          { username },
          result.authResponse.accessToken,
          result.authResponse.refreshToken
        );
        console.log("Login successful.");
      } else {
        console.log("Authentication failed.");
      }
    } catch (err) {
      console.log(
        "Login failed: ",
        err instanceof Error ? err.message : "Unknown error"
      );
    }
  }
};

//   const loginUser = async (email: string, password: string) => {
//   try {
//     const result = await apiClient<{ user: any; token: string }>(
//       "http://localhost:5056/api/auth/login",
//       {
//         method: "POST",
//         body: JSON.stringify({ email, password }),
//       }
//     );

//    // useAuthStore.getState().setUser(result.user, result.token);
//     console.log("Login successful:", result.token);
//   } catch (err) {
//     alert("Login failed: " + (err instanceof Error ? err.message : "Unknown error"));
//   }
// };

  return (
    <>
      <Headers />
      <Container maxWidth="sm" className={classes.container}>
        {/* E-commerce Logo */}
        <Typography variant="h3" className={classes.logo}>
          Ecomm<span className={classes.highlight}>Store</span>
        </Typography>

        <Box className={classes.card}>
          <Typography variant="h4" align="center" gutterBottom>
            Login
          </Typography>

          {/* Username/Password Login */}
          <Box component="form" className={classes.form} onSubmit={handleSubmit}>
            <TextField
              fullWidth
              label="Email/Username"
              variant="outlined"
              margin="normal"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              error={!!errors.username}
              helperText={errors.username}
            />
            <TextField
              fullWidth
              label="Password"
              type="password"
              variant="outlined"
              margin="normal"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              error={!!errors.password}
              helperText={errors.password}
            />
            <Button
              fullWidth
              variant="contained"
              color="primary"
              className={classes.button}
              type="submit"
            >
              Login
            </Button>
          </Box>

          {/* Divider */}
          <Divider className={classes.divider}>Or login with</Divider>

          {/* Social Media Login */}
          <Stack direction="row" spacing={2} justifyContent="center">
            <FacebookIcon className={classes.socialIcon} />
            <GoogleIcon className={classes.socialIcon} />
            <TwitterIcon className={classes.socialIcon} />
          </Stack>
        </Box>
      </Container>
    </>
  );
};

export default Login;