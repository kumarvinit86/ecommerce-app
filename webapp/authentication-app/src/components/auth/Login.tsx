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

// Define styles using Material-UI's makeStyles
const useStyles = makeStyles({
  container: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    justifyContent: "center",
    minHeight: "100vh",
    backgroundColor: "#f8fafc",
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

  // Handle form submission
  const handleSubmit = (e: React.FormEvent) => {
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
      console.log("Logging in with:", { username, password });
      // Add your login logic here (e.g., API call)
    }
  };

  return (
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
            label="Username"
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
  );
};

export default Login;