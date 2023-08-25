#install libarary
library(tidyverse)
library(ggplot2)
library(leaflet)
library(shiny)
library(lubridate)
library(plotly)
library(shinythemes)

# Read data from the CSV
data <- read.csv("foodwaste.csv")

ui <- shiny::fluidPage(
  shiny::titlePanel("Product Impact Visualization"),
  
  shiny::sidebarLayout(
    shiny::sidebarPanel(
      shiny::selectInput("product", "Choose products:", 
                         choices = data$Product, multiple = TRUE),
      shiny::uiOutput("quantityInputs") # Placeholder for dynamic UI elements
    ),
    
    shiny::mainPanel(
      shiny::textOutput("productInfo"), # Text output to display product details
      shiny::plotOutput("barPlot")
    )
  )
)

server <- function(input, output, session) {
  
  # Dynamically generate numeric input fields based on selected products
  output$quantityInputs <- shiny::renderUI({
    if (is.null(input$product)) return(NULL)
    inputFields <- lapply(input$product, function(prod) {
      shiny::numericInput(paste0("quantity_", prod), label = paste("Quantity for", prod), value = 1, min = 1)
    })
    do.call(shiny::tagList, inputFields)
  })
  
  output$productInfo <- shiny::renderText({
    if (is.null(input$product)) return(NULL)
    
    # Create a vector to store product details
    details <- c()
    
    for (prod in input$product) {
      qty <- as.numeric(input[[paste0("quantity_", prod)]])
      prod_values <- data[data$Product == prod, -1] * qty
      details <- c(details, paste(prod, ":", paste(names(prod_values), round(prod_values, 2), collapse=", ")))
    }
    
    # Convert the details vector to a single string and return
    paste(details, collapse = "<br/>")
  })
  
  output$barPlot <- shiny::renderPlot({
    # Check if any product is selected
    if (is.null(input$product)) return(NULL)
    
    # Filter data based on the selected products
    selected_data <- data[data$Product %in% input$product, ]
    
    # Modify values based on input quantities
    for (prod in input$product) {
      qty <- as.numeric(input[[paste0("quantity_", prod)]])
      selected_data[selected_data$Product == prod, -1] <- selected_data[selected_data$Product == prod, -1] * qty
    }
    
    # Convert data to long format for easy ggplot2 plotting
    long_data <- tidyr::gather(selected_data, Key, Value, -Product)
    
    p <- ggplot2::ggplot(long_data, aes(x = Key, y = Value, fill = Product)) +
      ggplot2::geom_bar(stat = "identity", position = "dodge") +
      ggplot2::geom_text(aes(label = round(Value, 2)), position = ggplot2::position_dodge(width = 0.9), vjust = -0.25) +
      ggplot2::labs(title = paste("Impact of", paste(input$product, collapse = ", ")), y = "Value") +
      ggplot2::theme_minimal() +
      ggplot2::scale_fill_brewer(palette = "Set1")
    
    print(p)
  })
}

shiny::shinyApp(ui, server)
