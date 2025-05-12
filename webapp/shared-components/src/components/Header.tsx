import React from "react";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";


const Header: React.FC = () => {
  return (
    <AppBar position="static" color="default" elevation={2}>
      <Toolbar sx={{ justifyContent: "space-between" }}>
        {/* Left: App Title */}
        <Typography variant="h6" color="primary" fontWeight="bold">
          eCommerce
        </Typography>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
