import React from "react";
import {
  Box,
  Container,
  TextField,
  Typography,
  Divider,
  Stack,
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
  socialText: {
    fontSize: "1rem",
    fontWeight: "bold",
    cursor: "pointer",
    transition: "color 0.3s ease",
    "&:hover": {
      color: "#007bff",
    },
  },
  // Add this to the `useStyles` object in your Login.tsx file
  socialIcon: {
    fontSize: "2rem", // Adjust the size of the icons
    cursor: "pointer",
    transition: "color 0.3s ease, transform 0.3s ease", // Smooth hover effects
    "&:hover": {
      color: "#007bff", // Change color on hover
      transform: "scale(1.2)", // Slightly enlarge the icon on hover
    },
  },
});

const Login: React.FC = () => {
  const classes = useStyles();

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
        <Box component="form" className={classes.form}>
          <TextField
            fullWidth
            label="Username"
            variant="outlined"
            margin="normal"
          />
          <TextField
            fullWidth
            label="Password"
            type="password"
            variant="outlined"
            margin="normal"
          />
          <Box className={classes.button} role="button">
            Login
          </Box>
        </Box>

        {/* Divider */}
        <Divider className={classes.divider}>Or login with</Divider>

        {/* Social Media Login with Icons */}
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